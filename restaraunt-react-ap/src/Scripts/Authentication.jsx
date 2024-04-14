import * as React from "react";
import axios from 'axios';

const Authentication = () => {

    const SendData = () => {
        var nameValue = document.getElementById("nameInput").value;
        var passwordValue = document.getElementById("passwordInput").value;

        var jsonData = {
            "name": nameValue,
            "password": passwordValue
        };

        RealSend(jsonData);
}

    const RealSend = (jsonData) => {
        axios.post('https://localhost:7072/api/authentication/sendData', jsonData)
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.error('No, erroe:', error);
            });
    }

    return (
        <div>
            <h3>Name</h3>
            <input type="text" id="nameInput"/>

            <h3>Password</h3>
            <input type="password" id="passwordInput" />

            <input type="button" value="Send data" onClick={SendData} />
        </div>
    )
}

export default Authentication;