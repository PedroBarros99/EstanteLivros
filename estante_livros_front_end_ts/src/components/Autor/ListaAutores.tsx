import React, { useState, useEffect } from "react";
import axios from "axios";
import { Link } from "react-router-dom";

export default function ListaAutores(props: any) {
  const [autores, definirAutores] = useState<any[]>([]);

  useEffect(() => {
    obterAutores();
  }, []);

  const obterAutores = async () => {
    const resposta = await axios.get("https://localhost:7189/api/Autors");
    // console.log(resposta.data);
    definirAutores(resposta.data);
  };

  const apagarAutores = async (id: any) => {
    const resposta = await axios.delete(
      `https://localhost:7189/api/Autors/${id}`
    );
    console.log(resposta);
    obterAutores();
  };

  return( 
    <>
      <h2>Lista de Autores</h2>
      <Link to="/AdicionarAutor" className="btn btn-primary me-1">Adicionar Autor</Link>
      <Link to="/" className="btn btn-secondary">Livros</Link>
      <table className="table table-hover">
        <thead>
          <tr>
            <th scope="col">Nome do Autor</th>
            <th></th>
          </tr>
        </thead>

        <tbody>
        {autores.map((autor, index) => (
            <tr key={autor.id}>
              <td>{autor.nomeAutor}</td>
              <td>
                <Link to={`/EditarAutor/${autor.id}`} className="btn btn-primary btn-sm me-1">Editar</Link>
                <button onClick={ () => apagarAutores(autor.id)} className="btn btn-danger btn-sm">Apagar</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </>

  )
}