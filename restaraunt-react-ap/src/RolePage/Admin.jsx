import axios from "axios"
import { useState } from "react";

const Admin = () => {
    const [products, setProducts] = useState([]);
    const [showOrderButton, setShowOrderButton] = useState(false);
    const [orderedProducts, setOrderedProducts] = useState([]);

    const getProducts = () =>
    {
        axios.get('https://localhost:7072/api/product/getProductsToBuy')
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
        axios.post('https://localhost:7072/api/product/makeOrder', orderedProducts)
            .then(response => {
                console.log(response.data);
            })
    }
     
    return (
        <div>
            <input type="button" value="Buy products?" onClick={getProducts} />
            <div>
                {products.map(product => (
                    <Product key={product.id} name={product.name} price={product.price} />
                ))}
            </div>
            {showOrderButton && <button onClick={(BuyProducts)}> Make order </button>}
        </div>

    );
}
export default Admin