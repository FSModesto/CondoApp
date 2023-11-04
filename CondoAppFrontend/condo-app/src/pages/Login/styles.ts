import styled from "styled-components";
import prediosImage from '../../images/predios.jpeg';


export const ContainerLogin = styled.div<{variavel: boolean}>`
    margin: auto;
    max-width: 480px;
    background-color: ${({ variavel }) => !variavel ? 'green' : 'red' };
    background-image: url(${prediosImage});
    background-position: center;
    height: 100vh;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
`

export const EmaileSenha = styled.input<{ validacampos: boolean}>`
    height: 50px;
    width: 300px;
    border-radius: 5px;
    border: 2px solid ${({ validacampos }) => !validacampos ? 'red' : 'none' };
    margin-bottom: 13px;
    padding: 2%;
    font-size: 14px;
`

export const LoginBotao = styled.button`
    height: 40px;
    width: 300px;
    margin-top: 50px;
    background-color: aquamarine;
    color: black;
    font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
    font-size: 20px;
    border-radius: 10px;
    border: none;


    &:hover {
        cursor: pointer;
        box-shadow: 0px 0px 3px 2px rgba(255, 255, 255, 0.5);
    }
`

export const Titulo = styled.h1`
    position: absolute;
    top: 100px;
    font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
    font-size: 42px;
    color: white;
`
export const EsqueciSenha = styled.p`
    text-decoration: underline;
    color: white;
`
