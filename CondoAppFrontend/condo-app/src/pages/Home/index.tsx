import React, { useEffect } from "react";
import { useHistory } from "react-router-dom";
import { ContainerHome, TituloHome, Cards, Card, Links, Page, IconeNotify, Footer} from "./styles";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars, faUser, faBell, faTags, faBuilding} from '@fortawesome/free-solid-svg-icons';


const Home = () => {
    const router = useHistory();
    
    useEffect(() => {
        if (!localStorage.getItem('Authorization')) {
            router.push('/login');
        }
    }, [])
    

    
    
    return (
        <ContainerHome>
            <IconeNotify>
                <FontAwesomeIcon icon={faBars} color="black" size="2x" />
                <FontAwesomeIcon icon={faBell} color="black" size="2x" />
            </IconeNotify>
            <TituloHome>CondoApp</TituloHome>
            <Cards>
                <Card cor="#6e7bf4">Financeiro</Card>
                <Card cor="#ffd260">Reuniões</Card>
            </Cards>
            <Cards>
                <Card cor="#3aa6be">Avisos</Card>
                <Card cor="#ff9960">Eventos</Card>
            </Cards>
            <Links>
                <Page onClick={() => router.push('/reservas')} backgroundImage={require('../../images/reservar.jpg')}>
                    <p>Reservar</p>
                </Page>
            </Links>
            <Links>
                <Page backgroundImage={require('../../images/administracao.jpg')}>
                    <p>Administração</p>
                </Page>
            </Links>
            <Footer>
                <FontAwesomeIcon icon={faUser} color="black" size="2x" />
                <FontAwesomeIcon icon={faBuilding} color="black" size="2x" />
                <FontAwesomeIcon icon={faTags} color="black" size="2x" />
            </Footer>  
        </ContainerHome>
    ) 
}

export default Home;