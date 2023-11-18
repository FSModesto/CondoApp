import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars, faUser, faBell, faTags, faBuilding} from '@fortawesome/free-solid-svg-icons';
import { ContainerHome, TituloHome, Footer, IconeNotify, Conteudo, InputForms, SelectForms, Data, Titulo, MinhasReservas } from "./styles";
import { IToken } from "../../interfaces/localstorage.interfaces";
import axios from "axios";

const Reservas = () => {

    const [title, setTitle] = useState('');
    const [leisureSpace, setLeisureSpace] = useState('');
    const [dateTime, setDate] = useState('');
    const [error, setError] = useState(false);
    const [loading, setLoading] = useState(false);
    const user: IToken = JSON.parse(localStorage.getItem('Authorization') || '');
    const [eventos, setEventos] = useState([]);
    const [loadingEventos, setLoadingEventos] = useState(false);
    
    
    const request = async () => {
        
        setLoading(true);
        setError(false);
        
        
        const dataRequest = {
            title, leisureSpace, dateTime
        }


        axios.post(`http://localhost:5133/Reservation/${user.id}`, dataRequest, { 
            headers: {
                'Authorization': `Bearer ${user.token}`
            }
        })
        .then((response) => {
            getEventos();
        }).catch((error) => { 
            setError(true);
        })
        
        
        setLoading(false);
    }


    const getEventos = async () => {
        axios.get(`http://localhost:5133/Reservation/${user.id}`, {
        headers: {
                'Authorization': `Bearer ${user.token}`
            }
        })
        .then((response) => {
            setEventos(response.data);  
        }).catch((error) => { 
            setError(true);
        })
    }

    useEffect(() => {
        getEventos();
    }, [])

    return (
        <ContainerHome>
            <IconeNotify>
                <FontAwesomeIcon icon={faBars} color="black" size="2x" />
                <FontAwesomeIcon icon={faBell} color="black" size="2x" />
            </IconeNotify>
            <TituloHome>CondoApp</TituloHome>
            <Conteudo>
                <MinhasReservas>
                    <div>

                    <p>Minhas Reservas</p> 

                    <div style={{ overflowY: 'auto', height: '220px' }}>

                        {loadingEventos && <p>Carregando...</p>} 
                        
                        {!loadingEventos &&
                            eventos.map((evento: any) => (
                                <div>
                                    <p>{evento.title} - {evento.leisureSpace} - {evento.dateTime} </p>
                                </div>
                            ))
                        }
                    </div>
                        </div>
                </MinhasReservas>
                <Titulo>Reservar</Titulo>
                <InputForms onChange={(e) => setTitle(e.target.value)} placeholder="Titulo do evento" />
                <SelectForms onChange={(e) => setLeisureSpace(e.target.value)} placeholder="Local do evento">
                    <option> Selecione uma opção</option>
                    <option value="option1">Churrasqueira</option>
                    <option value="option2">Salão de festas</option>
                    <option value="option3">Sala de jogos</option>
                </SelectForms>
                <Data onChange={(e) => setDate(e.target.value)} type="date" placeholder="Data do evento"/>
                <button onClick={request} disabled={ title === ('') || leisureSpace === ('') || dateTime === ('')  || loading }>adicionar</button>
            </Conteudo>
            <Footer>
                <FontAwesomeIcon icon={faUser} color="black" size="2x" />
                <FontAwesomeIcon icon={faBuilding} color="black" size="2x" />
                <FontAwesomeIcon icon={faTags} color="black" size="2x" />
            </Footer>
        </ContainerHome>  
    )
}

export default Reservas;