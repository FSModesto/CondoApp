import styled from "styled-components";
import administracaoImage from '../../images/administracao.jpg';
import reservarImage from '../../images/reservar.jpg';

export const ContainerHome = styled.div`
    margin: auto;
    max-width: 480px;
    background-color: #F5F5F5;
    height: 100vh;
`

export const TituloHome = styled.h1`
    display: flex;
    justify-content: center;
    top: 100px;
    font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
    font-size: 42px;
    margin-top: 15px;
`

export const Cards = styled.div`
    display: flex;
    margin: 10px;
    height: 150px;
`

export const Card = styled.button<{cor: string}>`
    background-color: ${({cor}) => cor};
    width: 50%;
    margin: 5px;
    border: none;
    border-radius: 5px;
    display: flex;
    align-items: end;
    justify-content: left;
    font-size: 20px;
    font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;

`
export const Links = styled.div`
    display: flex;
    margin: 10px;
    height: 200px;
`
export const Page = styled.button<{backgroundImage: string}>`
    width: 100%;
    margin: 5px;
    border: none;
    border-radius: 5px;
    display: flex;
    align-items: center;
    justify-content: center;
    background-image: url(${({ backgroundImage }) => backgroundImage});
    background-position: center;
    background-size: cover;
    margin-bottom: 0px;
    &:hover {
        cursor: pointer;
    }
    p {
        background-color: black;
        opacity: 80%;
        color: white;
        width: 100%;
        height: 30px;
        display: flex;
        justify-content: center;
        align-items: center;
    }
`
export const IconeNotify = styled.div`
    display: flex;
    justify-content: space-between;
    padding: 2%;

`
export const Footer = styled.div`
    background-color: #699dcc;
    height: 30px;
    display: flex;
    justify-content: space-between;
    padding: 10px;
`
