import React from "react";
import { Routes, Route } from "react-router-dom";
import ListaLivros from "./components/ListaLivros";
import AdicionarAutor from "./components/AdicionarAutor";
import ListaAutores from "./components/ListaAutores";
import AdicionarLivro from "./components/AdicionarLivro";
import EditarAutor from "./components/EditarAutor";
import EditarLivro from "./components/EditarLivro";
// import MostrarLivros from "./components/MostrarLivros";
// import SearchBar from "./components/SearchBar";

function App() {
  
  // const [searchTerm, setSearchTerm] = useState('');

  // const handleSearch = (searchTerm) => {
  //   setSearchTerm(searchTerm);
  // };
  
  return (
    <div className="container">
      <div className="row">
        <div className="col"> 
          <h1 className="text-center mb-5">Estante online</h1>
          <Routes>
            <Route path="/" element={<ListaLivros />}/>
            <Route path="/AdicionarLivro" element={<AdicionarLivro />} />
            <Route path="/EditarLivro/:id" element={<EditarLivro />} />
            <Route path="/AdicionarAutor" element={<AdicionarAutor />} />
            <Route path="/EditarAutor/:id" element={<EditarAutor />} />
            <Route path="/ListaAutores" element={<ListaAutores />} />
          </Routes>
        </div>
      </div>
    </div>
  );
}

export default App;
