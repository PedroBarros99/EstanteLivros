import React, { useEffect, useState } from "react";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom"; 

export default function AdicionarLivro() {
  const [autor, setAutor] = useState({
    nomeAutor: ""
  });
  const navigate = useNavigate();

  const guardarAutor = async (e) => {
    e.preventDefault();
    // console.log(autor);
    await axios.post("https://localhost:7189/api/Autors", {
      nomeAutor: autor.nomeAutor
    });
    navigate("/ListaAutores");
  };

  function atualizarNomeAutor(evento) {
    setAutor({ ...autor, nomeAutor: evento.target.value });
  }

  return (
    <div>
      <h1>Adicionar Autor</h1>
      <form onSubmit={guardarAutor}>
        <div className="form-floating mb-1">
          <input
          id="nomeAutor"
          className="form-control"
          type="text"
          onChange={atualizarNomeAutor}
          value={autor.nomeAutor}
          placeholder="Nome do Autor"
          />
          <label className="form-label" htmlFor="nomeAutor">
            Nome do Autor
          </label>
        </div>

        <div className="mt-2">
          <button className="btn btn-primary me-2" type="submit">
            Guardar
          </button>
          <Link to={"/"} className="btn btn-secondary">
            Cancelar
          </Link>
        </div>
      </form>
    </div>
  )
}



