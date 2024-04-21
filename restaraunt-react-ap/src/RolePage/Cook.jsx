import axios from 'axios';
import React, { useState } from 'react';

function Cook() {
    const [dishName, setDishName] = useState('');
    const [ingredients, setIngredients] = useState([{ name: '', amount: '' }]);
    const [dictionaryDish, setDictionaryDish] = useState({ name: '', ingridients: [] });

    const handleInputChange = (index, event) => {
        const { name, value } = event.target;
        const list = [...ingredients];
        list[index][name] = value;
        setIngredients(list);

        setDictionaryDish({ name: dishName, ingridients: ingredients });
    };

    const handleAddIngredient = () => {
        setIngredients([...ingredients, { name: '', amount: '' }]);
    };

    const AddNewDish = () => {
        axios.post('https://localhost:7072/api/cook/addDish', dictionaryDish)
            .then(response => {
                console.log(response.data);
            })

    };

    return (
        <div>
            <input
                type="text"
                placeholder="Enter dish name"
                value={dishName}
                onChange={(e) => setDishName(e.target.value)}
            />
            <br />
            {ingredients.map((ingredient, index) => (
                <div key={index}>
                    <input
                        type="text"
                        placeholder="Enter ingredient name"
                        name="name"
                        value={ingredient.name}
                        onChange={(e) => handleInputChange(index, e)}
                    />
                    <input
                        type="number"
                        placeholder="Enter ingredient amount"
                        name="amount"
                        value={ingredient.amount}
                        onChange={(e) => handleInputChange(index, e)}
                    />
                </div>
            ))}
            <button type="button" onClick={handleAddIngredient}>Add Ingredient</button>
            <br />
            <button type="button" onClick={AddNewDish}>Add new dish</button>
        </div>
    );
}

export default Cook;
