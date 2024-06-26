﻿import axios from "axios"
import { useEffect, useState } from "react";

const Admin = () => {
    const [products, setProducts] = useState([]);
    const [showOrderButton, setShowOrderButton] = useState(false);
    const [orderedProducts, setOrderedProducts] = useState([]);

    const [dishList, setDishList] = useState([]);
    const [dayMenu, setDayMenu] = useState([]);


    const getProducts = () =>
    {
        axios.get('https://localhost:7072/api/admin/getProductsToBuy')
            .then(response => {
                setProducts(response.data);
                setShowOrderButton(true);
            })
    }

    const Product = ({ name, price }) => {
        return (
            <div>
                <span>{name}: ${price}</span>
                <input type="button" value="+" onClick={() => SetPriceToButton(name, 1)} />
            </div>
        );
    }

    const SetPriceToButton = (name, value) => {
        const updatedCounter = { ...orderedProducts };

        if (updatedCounter[name]) {
            updatedCounter[name] += value;
        } else {
            updatedCounter[name] = value;
        }

        setOrderedProducts(updatedCounter);
    }

    const BuyProducts = () => {
        axios.post('https://localhost:7072/api/admin/makeOrder', orderedProducts)
            .then(response => {
                console.log(response.data);
            })
    }

    const GetMenuList = () => {
        axios.get("https://localhost:7072/api/admin/getDishList")
            .then(response => {
                setDishList(response.data);
            }) 
    }

    const Dish = ({ name }) => {
        const [isChecked, setIsChecked] = useState(false);

        useEffect(() => {
            setIsChecked(dayMenu.includes(name));
        }, [dayMenu, name]);

        const handleCheckboxChange = (event) => {
            const isChecked = event.target.checked;

            setIsChecked(isChecked);

            if (isChecked) {
                setDayMenu(prevDayMenu => [...prevDayMenu, name]);
            } else {
                setDayMenu(prevDayMenu => prevDayMenu.filter(item => item !== name));
            }
        };

        return (
            <div>
                <span>{name}</span>
                <input type="checkbox" id={name + "id"} checked={isChecked} onChange={handleCheckboxChange} />
            </div>
        );
    };

    const PostDailyMenu = () => {
        axios.post('https://localhost:7072/api/admin/setDailyMenu', dayMenu)
            .then(response => {
                console.log(response.data);
            })
    }
    
    return (
        <div>
            <input type="button" value="Buy products" onClick={getProducts} />

            <input type="button" value="Make daily menu" onClick={GetMenuList} />
            <div>
                {products.map(product => (
                    <Product key={product.id} name={product.name} price={product.price} />
                ))}

                {dishList.map(dish =>
                    <Dish name={dish.name} key={dish.name + "dish"} />
                )}

                {dishList.length > 0 && <input type="button" value="Post daily menu" onClick={PostDailyMenu} />}
            </div>
            {showOrderButton && <button onClick={(BuyProducts)}> Make order </button>}
        </div>

    );
}
export default Admin