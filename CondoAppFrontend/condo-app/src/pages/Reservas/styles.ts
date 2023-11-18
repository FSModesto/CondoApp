
import styled from "styled-components";
import reserva from '../../images/reservar.jpg';

export const Footer = styled.div`
    background-color: #699dcc;
    height: 30px;
    display: flex;
    justify-content: space-between;
    padding: 10px;
`
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
export const IconeNotify = styled.div`
    display: flex;
    justify-content: space-between;
    padding: 2%;

`
export const Conteudo = styled.div`
    background-image: url(${reserva});
    background-size: cover;
    height: 80vh;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
`
export const InputForms = styled.input`
    width: 70%;
    height: 40px;
    background-color: #d0cfcf;
    border: none;
    border-radius: 5px;
    margin-bottom: 10px;
`
export const SelectForms = styled.select`
    width: 70%;
    height: 40px;
    border: none;
    border-radius: 5px;
    margin-bottom: 10px;
`
export const Data = styled.input`
    width: 70%;
    height: 40px;
    background-color: #d0cfcf;
    border: none;
    border-radius: 5px;
`
export const Titulo = styled.h1`
    font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
`

export const MinhasReservas = styled.div`
    height: 40%;
    width: 350px;
    background-color: beige;
    opacity: 0.6;
    display: flex;
    justify-content: center;
    border-radius: 10px;
    p{
        text-align: center;
        opacity: 1;
        font-style: bold;
        font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
    }
`