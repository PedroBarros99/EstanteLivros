import React, { useState, useEffect } from "react";
import axios from "axios";
import { Link, useNavigate, useParams } from "react-router-dom";

export default function EditarAutor() {
  const [autor, setAutor] = useState({
    nomeAutor: ""
  });
  const navigate = useNavigate();
  const { id } = useParams();

  const atualizarAutor = async (e) => {
    e.preventDefault();
    await axios.patch(`http://localhost:5000/espetaculos/${id}`, {
      nome_autor: autor.nomeAutor
    });
    navigate("/EditarEspetaculos");
  };

  useEffect(() => {
    obterAutorPorID();
  }, []);

  const obterAutorPorID = async () => {
    const resposta = await axios.get(`http://localhost:5000/espetaculos/${id}`);

    setAutor({
      nomeAutor: resposta.data.nome_autor
    })
  };

  function atualizarNomeAutor(evento) {
    setAutor({ ...autor, nomeAutor: evento.target.value });
  }

  return (
    <div>
      <h2>Editar Autor</h2>
      <form onSubmit={atualizarAutor}>
        <div className="mb-3">
          <label className="form-label">Nome do Autor:</label> 
          <input className="form-control"
            type="text"
            onChange={atualizarNomeAutor}
            value={autor.nomeAutor}
          />
          
        </div>

        <div>
          <button className="btn btn-primary me-2">Atualizar</button>
          <Link to={"/EditarEspetaculos"} className="btn btn-secondary">Cancelar</Link>
        </div>
      </form>
    </div>
  );
}