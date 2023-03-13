import React, { useState, useEffect } from "react";
import axios from "axios";
import { Link, useNavigate, useParams } from "react-router-dom";

export default function EditarAutor() {
  const [autor, setAutor] = useState({
    nomeAutor: "",
  });
  const navigate = useNavigate();
  const { id } = useParams();

  const atualizarAutor = async (e) => {
    e.preventDefault();
    console.table(autor);
    console.log(id);
    await axios.put(`https://localhost:7189/api/Autors/${id}`, {
      ID: id,
      nomeAutor: autor.nomeAutor,
    });
    navigate("/ListaAutores");
  };

  const obterAutorPorID = async () => {
    const resposta = await axios.get(`https://localhost:7189/api/Autors/${id}`);
    console.log(resposta.data);
    setAutor({
      nomeAutor: resposta.data.nomeAutor,
    });
  };

  useEffect(() => {
    obterAutorPorID();
  }, []);

  function atualizarNomeAutor(evento) {
    setAutor({ ...autor, nomeAutor: evento.target.value });
  }

  return (
    <div>
      <h2>Editar Autor</h2>
      <form onSubmit={atualizarAutor}>
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

          <div className="mt-2">
            <button className="btn btn-primary me-2" type="submit">
              Guardar
            </button>
            <Link to={"/"} className="btn btn-secondary">
              Cancelar
            </Link>
          </div>
        </div>
      </form>
    </div>
  );
}
