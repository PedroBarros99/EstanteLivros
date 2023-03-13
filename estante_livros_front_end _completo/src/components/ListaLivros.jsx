import React, { useState, useEffect } from "react";
import axios from "axios";
import { Link } from "react-router-dom";

export default function ListaLivros(props) {
  const [livros, definirLivros] = useState([]);

  const [pesquisa, setPesquisa] = useState({
    termo: ""
  });

  useEffect(() => {
    obterLivros();
  }, []);

  const obterLivros = async () => {
    const resposta = await axios.get("https://localhost:7189/api/Livros");
    // console.log(resposta.data);
    definirLivros(resposta.data);
  };

  const obterLivrosPesquisa = async (termo) => {
    const resposta = await axios.get("https://localhost:7189/api/Livros/PesquisarLivros", {params: {termoPesquisa: termo}});
    // console.log(resposta.data);
    definirLivros(resposta.data);
  };

  const apagarLivros = async (id) => {
    const resposta = await axios.delete(
      `https://localhost:7189/api/Livros/${id}`
    );
    console.log(resposta);
    obterLivros();
  };

  function atualizarPesquisa(evento) {
    setPesquisa({ ...pesquisa, termo: evento.target.value });
  }

  const efetuarPesquisa = async (e) => {
    e.preventDefault();
    console.log("efetuarPesquisa")
    if (pesquisa.termo === "") {
      obterLivros()
    }
    else {
      obterLivrosPesquisa(pesquisa.termo)
      setPesquisa({ ...pesquisa, termo: "" });
    }
  };

  return (
    <>
      <h2>Lista de Livros</h2>
      <div className="container">
        <div className="row">
          <div className="col-4">
            <Link to="/AdicionarLivro" className="btn btn-primary me-2">
              Adicionar Livro
            </Link>
            <Link to="/ListaAutores" className="btn btn-secondary">
              Autores
            </Link>
          </div>
          <div className="col">
            <form onSubmit={efetuarPesquisa}>
              <div className="form-floating">
                <input
                  id="pesquisaInput"
                  className="form-control form-control-sm"
                  type="text"
                  onChange={atualizarPesquisa}
                  value={pesquisa.termo}
                  placeholder="Pesquisar"
                />

                <label className="form-label" htmlFor="pesquisaInput">
                  Pesquisar
                </label>
              </div>
            </form>
          </div>
        </div>
      </div>

      <table className="table table-hover">
        <thead>
          <tr>
            <th scope="col">Nome do Livro</th>
            <th scope="col">ISBN</th>
            <th scope="col">Nome do Autor</th>
            <th scope="col">Preço do livro</th>
            <th scope="col"></th>
          </tr>
        </thead>

        <tbody>
          {livros.map((livro, index) => (
            <tr key={livro.id}>
              <td>{livro.nomeLivro}</td>
              <td>{livro.isbn}</td>
              <td>{livro.autor.nomeAutor}</td>
              <td>{livro.precoLivro}</td>
              <td>
                <Link
                  to={`/EditarLivro/${livro.id}`}
                  className="btn btn-primary btn-sm me-1"
                >
                  Editar
                </Link>
                <button
                  onClick={() => apagarLivros(livro.id)}
                  className="btn btn-danger btn-sm"
                >
                  Apagar
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}
