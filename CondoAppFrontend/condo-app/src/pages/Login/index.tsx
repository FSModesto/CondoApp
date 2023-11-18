import axios from "axios";
import React, { useEffect } from "react";
import { FC, useState } from "react";
import { ContainerLogin, EmaileSenha, LoginBotao, Titulo, EsqueciSenha} from "./styles";
import { useHistory } from "react-router-dom";
import { IToken } from "../../interfaces/localstorage.interfaces";


const Login:FC = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState(false);
    const [validacao, setValidacao] = useState({
        email: true,
        password: true,
    });
    const router = useHistory();

    const send = async ()  => {
        setError(false);

        if (email === ('') && password === ('')) {
            setValidacao({
                email: false,
                password: false
            })
            return;
        }

        if (email === ('')) {
            setValidacao({
                ...validacao,
                email: false,
            })
            return;
        }
        if (password === ('')) {
            setValidacao({
                ...validacao,
                password: false,
            })
            return;
        }
        
        const request = {
            email, password
        }

        axios.post('http://localhost:5133/User/logins', request)
        .then((response: {data: IToken}) => {
            localStorage.setItem("Authorization",JSON.stringify(response.data));
            router.push('/');
        }).catch((error) => { 
            setError(true);
        })     
    }

    useEffect(() => {
        if (localStorage.getItem('Authorization')) {
            router.push('/');
        }
    }, [])

    return (
        <ContainerLogin variavel={error}>
            <Titulo>CondoApp</Titulo>
            <EmaileSenha validacampos={validacao.email} value={email} onChange={e => setEmail(e.target.value)} type="email" placeholder="Email@example.com" />
            {!validacao.email && <p style={{color: 'red'}}>Preencha o campo email</p>}
            <EmaileSenha validacampos={validacao.password} value={password} onChange={e => setPassword(e.target.value)} type="password" placeholder="Digite sua senha"/>
            {!validacao.password && <p style={{color: 'red'}}>Preencha o campo senha</p>}
            <EsqueciSenha>Esqueci minha senha</EsqueciSenha>
            <LoginBotao onClick={send}>Login</LoginBotao>
            {error && <p style={{color: 'red'}}>Usuario ou senha inválidos</p>}
        </ContainerLogin>
    ) 
};



export default Login;