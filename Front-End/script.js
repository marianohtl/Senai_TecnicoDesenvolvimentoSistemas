addEventListener('load', () => {
    Listar();
});

function Listar(){
    console.log(" =)");
    let list = document.getElementById('list');
    let list2 = document.getElementById('list2');

    fetch('http://localhost:5000/api/filmes')
        .then((response) =>  response.json()).then( (data) => {
            for(var i = 0; i < data.length; i++) {
                console.log(data[i].titulo);
                console.log(data[i].idGeneroNavigation.nome);
                
                var li = document.createElement('li');
                var li2 = document.createElement('li');
                li.textContent = data[i].titulo;
                li2.textContent = data[i].idGeneroNavigation.nome;
                list.appendChild(li);
                list2.appendChild(li2);

            
            }
        })
}