import React, { useState, useEffect } from "react";
import axios from "axios";
import { Link, useNavigate, useParams } from "react-router-dom";

export default function EditarLivro() {
  const [livro, setLivro] = useState({
    nomeLivro: "",
    isbn: "",
    precoLivro: ""
  });
  const navigate = useNavigate();
  const { id } = useParams();

  const atualizarLivro = async (e) => {
    e.preventDefault();
    await axios.patch(`http://localhost:5000/espetaculos/${id}`, {
      nome_livro: livro.nomeLivro,
      isbn: livro.isbn,
      preco_livro: livro.precoLivro
    });
    navigate("/EditarEspetaculos");
  };

  useEffect(() => {
    obterLivroPorID();
  }, []);

  const obterLivroPorID = async () => {
    const resposta = await axios.get(`http://localhost:5000/espetaculos/${id}`);

    setLivro({
      nomeLivro: resposta.data.nome_livro,
      isbn: resposta.data.isbn,
      precoLivro: resposta.data.preco_livro
    })
  };

  function atualizarNomeLivro(evento) {
    setLivro({ ...livro, nomeLivro: evento.target.value });
  }

  function atualizarISBN(evento) {
    setLivro({ ...livro, isbn: evento.target.value });
  }

  function atualizarPrecoLivro(evento) {
    setLivro({ ...livro, precoLivro: evento.target.value });
  }


  return (
    <div>
      <h2>Editar Livro</h2>
      <form onSubmit={atualizarLivro}>
        <div className="mb-3">
          <label className="form-label">Nome do Livro:</label> 
          <input className="form-control"
            type="text"
            onChange={atualizarNomeLivro}
            value={livro.nomeLivro}
          />
          
        </div>

        <div className="mb-3">
          <label className="form-label">ISBN:</label> 
          <input className="form-control w-25"
            type="text"
            onChange={atualizarISBN}
            value={livro.isbn}
          />
          
        </div>

        <div className="mb-3">
          <label className="form-label">Preço do Livro:</label> 
          <input className="form-control w-25"
            type="text"
            onChange={atualizarPrecoLivro}
            value={livro.precoLivro}
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