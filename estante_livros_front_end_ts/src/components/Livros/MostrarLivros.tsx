import { useState, useEffect } from "react";
import axios from "axios";


export default function MostrarLivro(props: any) {
  
  const [idLivro, setIdLivro] = useState(props.idLivro);

  const [livro, setLivro] = useState({
    nomeLivro: "",
    isbn: "",
    precoLivro: ""
  });
  
  useEffect(() => {
    obterLivro(idLivro);
  }, [idLivro]);
  
  const obterLivro = async (idLivro: any) => {
    const resposta = await axios.get(`http://localhost:5000/espetaculos/${idLivro}`);
    console.log(resposta.data)
    setLivro({
      nomeLivro: resposta.data.nome_livro,
      isbn: resposta.data.isbn,
      precoLivro: resposta.data.preco_livro
    })
  }

  return (
    <div className="card mb-3">
      <div className="card-body">
        <h5 className="card-title">Nome do Livro: {livro.nomeLivro}</h5>
        <p className="card-text">ISBN: {livro.isbn}</p>
        <p className="card-text">Preço do Livro: {livro.precoLivro}</p>
      </div>
    </div>

  )
}
