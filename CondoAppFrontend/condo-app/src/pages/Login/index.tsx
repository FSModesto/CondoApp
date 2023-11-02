import axios from "axios";
import React from "react";
import { FC, useState } from "react";

const Login:FC = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const send = async ()  => {

        if (email === ('') && password === ('')) {
            alert('Email and password is required');
            return;
        }

        if (email === ('')) {
            alert('Email is required');
            return;
        }
        if (password === ('')) {
            alert('Password is required');
            return;
        }
        
        const request = {
            email, password
        }

        axios.post('http://localhost:5133/User/logins', request)
        .then((response) => {
            localStorage.setItem("mykey",JSON.stringify(response.data));
            setEmail('');
            setPassword('');
        }).catch((error) => {
            console.log(error);
        })        
    }

    return (
        <div>
            <input value={email} onChange={e => setEmail(e.target.value)} type="text" />
            <br />
            <input value={password} onChange={e => setPassword(e.target.value)} type="password" />
            <br />
            <button onClick={send}>Login</button>
        </div>
    ) 
};



export default Login;