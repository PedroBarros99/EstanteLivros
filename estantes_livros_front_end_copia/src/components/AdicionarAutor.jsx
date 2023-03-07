import React, { useState } from "react";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";

export default function AdicionarAutor() {
  const [autor, setAutor] = useState({
    nomeAutor: ""
  });
  const navigate = useNavigate();

  const guardarAutor = async (e) => {
    e.preventDefault();
    await axios.post ('pôr link aqui do local host', {
      "nome_autor": autor.nomeAutor
    });
    navigate("/por aqui outra coisa")
  }

  function atualizarNomeAutor(evento){
    setAutor({...autor, nomeAutor:evento.target.value})
  }

  return (
    <div>
      <h2>Adicionar Autor</h2>
      <form onSubmit={guardarAutor}>
        <div>
          <label className="form-label">Nome do Autor:</label>
          <input className="form-control" type="text" onChange={atualizarNomeAutor} value={autor.nomeAutor}/>
        </div>
      </form>
    </div>
  )
}