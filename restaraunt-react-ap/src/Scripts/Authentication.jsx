import * as React from "react";
import axios from "axios";
import Cookies from "js-cookie";
import { BrowserRouter as Router, Route, Link, Routes, Navigate, useNavigate } from 'react-router-dom';

const Authentication = () => {
    const [role, setRole] = React.useState(null);

    const SendData = async () => {
        var nameValue = document.getElementById("nameInput").value;
        var passwordValue = document.getElementById("passwordInput").value;

        var jsonData = {
            "name": nameValue,
            "password": passwordValue
        };

        await RealSend(jsonData);
    }

    const RealSend = async (jsonData) => {
        try {
            const response = await axios.post('https://localhost:7072/api/authentication/sendData', jsonData);
            Cookies.set('token', '');
            if (response.data.role !== '') {
                const token = response.data.token;
                Cookies.set('token', token);
                setRole(response.data.role);

            }
        } catch (error) {
            console.error('No, error:', error.response.data);
        }
    }

    const DirectTo = ({ role }) => {
        const navigate = useNavigate();
        let linkToRender;

        switch (role) {
            case "administrator":
                navigate("/Admin");
                break;
            case "cook":
                navigate("/Cook");
                break;
            case "waiter":
                navigate("/Waiter");
                break;
            default:
                break;
        }

        return linkToRender;
    }


    const GetSecretInfo = () => {
        const token = Cookies.get('token');
        if (!token) {
            console.error('No token found');
            return;
        }

        axios.get('https://localhost:7072/api/testRole/getSecretInfo', {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then(function (response) {
                console.log(Cookies.get('token'));
                console.log(response.data);
            })
            .catch(function (error) {
                console.error('Error:', error);
            });
    }

    return (
        <div>
            <h3>Name</h3>
            <input type="text" id="nameInput" />

            <h3>Password</h3>
            <input type="password" id="passwordInput" />

            <input type="button" value="Send data" onClick={SendData} />

            <input type="button" value="Log or not?" onClick={GetSecretInfo} />

            {DirectTo({ role })}
        </div>
    )
}

export default Authentication;
