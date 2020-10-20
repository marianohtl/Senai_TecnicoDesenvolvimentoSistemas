import React, {useState} from 'react';
import logo from '../../assets/images/logo.png';

function Header(){return(

    <div className="header">
        <header>
            <nav>
                <div className="section-header"> 
                    <div className="img-nav">
                        <img src={logo} alt=""/> 
                    </div>
                    <div className="itens-nav">
                        <a>Perfil</a>
                        <a>Filmes</a>
                        <a>Gênero</a>
                    </div>
                </div>
            </nav>
        </header>
    </div>
);}

export default Header;