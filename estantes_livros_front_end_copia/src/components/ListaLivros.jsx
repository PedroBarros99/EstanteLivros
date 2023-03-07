import React, { useState, useEffect } from "react";
import axios from "axios";
import { Link } from "react-router-dom";


export default function ListaLivros(props) {

  const [livros, definirLivros] = useState([]);

  useEffect(() => {
    obterLivros();
  }, []);

  const obterLivros = async () => {
    const resposta = await axios.get('http://localhost:5000/espetaculos');
    definirLivros(resposta.data);
  }

  const apagarLivros = async (id) => {
    const resposta = await axios.delete(`http://localhost:5000/espetaculos/${id}`);
    console.log(resposta)
    obterLivros();
  }

  const editarLivro = props.editarLivro
  return (
    <>
      <h2>Lista de Livros</h2>
      {/* <Link to="/ComprarBilhete">Comprar bilhete</Link> <br /> */}
      
      {editarLivro &&
        <Link to="/AdicionarEspetaculo" className="btn btn-primary">Adicionar Livro</Link>}
      <table className="table table-hover">
        <thead>
          <tr>
            <th scope="col">Nome do Livro</th>
            <th scope="col">ISBN</th>
            <th scope="col">Nome do Autor</th>
            <th scope="col">Preço do livro</th>
          </tr>
        </thead>
        <tbody>
          { livros.map((livro, index) => (
            <tr key={livro.id}>
                <td>{livro.nome_livro}</td>
                <td>{livro.isbn}</td>
                <td>{livro.nome_autor}</td>
                <td>{livro.preco_livro}</td>
                <td>
                  {editarLivro && 
                    <>
                    <Link to={`/EditarEspetaculo/${livro.id}`} className="btn btn-primary btn-sm me-1">Editar</Link>
                    <button onClick={ () => apagarLivros(livro.id)} className="btn btn-danger btn-sm">Apagar</button>
                    </>
                  }
                  
                  {!editarLivro &&
                    <Link to={`/ComprarBilhete/${livro.id}`} className="btn btn-primary btn-sm">Comprar</Link>
                  }
                </td>
            </tr>
          )
          )}
        </tbody>
      </table>
    </>
  );
}