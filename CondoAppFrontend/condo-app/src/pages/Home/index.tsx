import React, { useEffect } from "react";
import { useHistory } from "react-router-dom";

const Home = () => {
    const router = useHistory();
    
    useEffect(() => {
        if (!localStorage.getItem('Authorization')) {
            router.push('/login');
        }
    }, [])
    
    return (
        <>
            <h1>Home</h1>
            <button>Reservas</button>
        </>
    )
}

export default Home;