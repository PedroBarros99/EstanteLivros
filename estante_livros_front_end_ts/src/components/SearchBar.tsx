import React, { useState } from 'react';

function SearchBar(props: any) {
  const [searchTerm, setSearchTerm] = useState('');

  const handleSubmit = (event: any) => {
    event.preventDefault();
    props.onSearch(searchTerm);
  };

  const handleChange = (event: any) => {
    setSearchTerm(event.target.value);
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        placeholder="Search"
        value={searchTerm}
        onChange={handleChange}
      />
      <button type="submit">Search</button>
    </form>
  );
}

export default SearchBar;