import React, { useState, useEffect } from "react";
import axios from "axios";
import { Link, useNavigate, useParams } from "react-router-dom";

export default function EditarLivro() {
  const [livro, setLivro] = useState({
    nomeLivro: "",
    isbn: "",
    precoLivro: "",
    idAutor: ""
  });
  const navigate = useNavigate();
  const { id } = useParams();

  const atualizarLivro = async (e: any) => {
    e.preventDefault();
    console.table(livro);
    console.log(id);
    await axios.put(`https://localhost:7189/api/Livros/${id}`, {
      ID: id,
      nomeLivro: livro.nomeLivro,
      isbn: livro.isbn,
      precoLivro: livro.precoLivro,
      idAutor: livro.idAutor
    });
    navigate("/");
  };

  const obterLivroPorID = async () => {
    const resposta = await axios.get(`https://localhost:7189/api/Livros/${id}`);
    console.log(resposta.data);
    setLivro({
      nomeLivro: resposta.data.nomeLivro,
      isbn: resposta.data.isbn,
      precoLivro: resposta.data.precoLivro,
      idAutor: resposta.data.idAutor
    });
  };
  
  useEffect(() => {
    obterLivroPorID();
  }, []);
  
  const [listaAutores, setListaAutores] = useState([]);
  
  const obterListaAutores = async () => {
    await axios.get("https://localhost:7189/api/Autors").then((resposta) => {
      setListaAutores(resposta.data);
      // console.log(listaAutores);
    });
  };

  useEffect(() => {
    obterListaAutores();
  }, []);
  
  function atualizarNomeLivro(evento: any) {
    setLivro({ ...livro, nomeLivro: evento.target.value });
  }

  function atualizarISBN(evento: any) {
    setLivro({ ...livro, isbn: evento.target.value });
  }

  function atualizarPrecoLivro(evento: any) {
    setLivro({ ...livro, precoLivro: evento.target.value });
  }

  function atualizarIDAutor(evento: any) {
    setLivro({ ...livro, idAutor: evento.target.value });
  }

  return (
    <div>
      <h2>Editar Livro</h2>
      <form onSubmit={atualizarLivro}>
        <div className="form-floating mb-1">
          <input
            id="nomeLivro"
            className="form-control"
            type="text"
            onChange={atualizarNomeLivro}
            value={livro.nomeLivro}
            placeholder="Nome do Livro"
          />
          <label className="form-label" htmlFor="nomeLivro">
            Nome do Livro
          </label>
        </div>

        <div className="form-floating mb-1">
          <input
            id="isbn"
            className="form-control"
            type="text"
            onChange={atualizarISBN}
            value={livro.isbn}
            placeholder="ISBN"
          />
          <label className="form-label" htmlFor="isbn">
            ISBN
          </label>
        </div>

        {/* <div className="form-floating mb-1">
          <input
            id="IDAutor"
            className="form-control"
            type="number"
            onChange={atualizarIDAutor}
            value={livro.idAutor}
            placeholder="Nome do Autor"
          />
          <label className="form-label" htmlFor="IDAutor">
            Nome do Autor
          </label>
        </div> */}

        <div className="mb-1">
          <label className="form-label" htmlFor="IDAutor">
            Nome do Autor:
            <select
              id="IDAutor"
              className="form-select"
              value={livro.idAutor}
              onChange={atualizarIDAutor}
            >
              {listaAutores.map((autor) => {
                return (
                  <option key={autor["id"]} value={autor["id"]}>
                    {autor["nomeAutor"]}
                  </option>
                );
              })}
            </select>
          </label>
        </div>

        <div className="form-floating mb-1">
          <input
            id="precoLivro"
            className="form-control"
            type="number"
            onChange={atualizarPrecoLivro}
            value={livro.precoLivro}
            placeholder="Preço do Livro"
          />
          <label className="form-label" htmlFor="precoLivro">
            Preço do Livro
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
  );
}
