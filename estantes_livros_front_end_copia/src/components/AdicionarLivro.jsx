import React, { useState } from "react";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";

export default function AdicionarLivro() {
  const [livro, setLivro] = useState({
    nomeLivro: "",
    isbn: "",
    precoLivro:""
  });
  const navigate = useNavigate();

  const guardarLivro = async (e) => {
    e.preventDefault();
    await axios.post ('pôr link aqui do local host', {
      "nome_livro": livro.nomeLivro,
      "isbn": livro.isbn,
      "preco_livro": livro.precoLivro
    });
    navigate("/por aqui outra coisa")
  }

  function atualizarNomeLivro(evento){
    setLivro({...livro, nomeLivro:evento.target.value})
  }

  function atualizarISBN(evento){
    setLivro({...livro, isbn:evento.target.value})
  }

  function atualizarPrecoLivro(evento){
    setLivro({...livro, precoLivro:evento.target.value})
  }

  return (
    <div>
      <h2>Adicionar Livro</h2>
      <form onSubmit={guardarLivro}>
        <div>
          <label className="form-label">Nome do Livro:</label>
          <input className="form-control" type="text" onChange={atualizarNomeLivro} value={livro.nomeLivro}/>
        </div>

        <div>
          <label className="form-label">ISBN:</label>
          <input className="form-control" type="text" onChange={atualizarISBN} value={livro.isbn}/>
        </div>

        <div>
          <label className="form-label">Preço do Livro:</label>
          <input className="form-control" type="text" onChange={atualizarPrecoLivro} value={livro.precoLivro}/>
        </div>
      </form>
    </div>

    

    
  )
}  