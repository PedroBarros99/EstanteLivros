import React, { useEffect, useState } from "react";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";

export default function AdicionarLivro() {
  const [livro, setLivro] = useState({
    nomeLivro: "",
    isbn: "",
    precoLivro: "",
    IDAutor: ""
  });
  const navigate = useNavigate();

  // const [autorSelecionado, setAutorSelecionado] = useState('')
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

  const guardarLivro = async (e) => {
    e.preventDefault();
    // console.log(livro);
    await axios.post("https://localhost:7189/api/Livros", {
      nomeLivro: livro.nomeLivro,
      isbn: livro.isbn,
      precoLivro: livro.precoLivro,
      IDAutor: livro.IDAutor
    });
    navigate("/");
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

  function atualizarIDAutor(evento) {
    setLivro({ ...livro, IDAutor: evento.target.value });
  }

  return (
    <div>
      <h2>Adicionar Livro</h2>
      <form onSubmit={guardarLivro}>
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
            value={livro.IDAutor}
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
              value={livro.IDAutor}
              onChange={atualizarIDAutor}
            >
              <option>Selecione um autor</option>
              {listaAutores.map((autor) => {
                return (
                  <option key={autor.id} value={autor.id}>
                    {autor.nomeAutor}
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
