import "./films.css";
// const filmsHits=[
//     {name:"panda",
//         img:"newfilms/new1.jpg"
//     },
//     {name:"spiderman",
//         img:"newfilms/new2.jpg"
//     },
//     {name:"harry",
//         img:"newfilms/new3.jpg"
//     }
// ]
//
// const filmsUpcoming=[
//     {name:"panda",
//         img:"upcoming/upcoming1.jpg"
//     },
//     {name:"spiderman",
//         img:"upcoming/upcoming2.jpg"
//     },
//     {name:"harry",
//         img:"upcoming/upcoming3.jpg"
//     }
// ]
//
// // eslint-disable-next-line react/prop-types
//  function FilmObj({film}){
//     return (
//         // eslint-disable-next-line react/prop-types
//         <li key={film.name}>
//             {/* eslint-disable-next-line react/prop-types */}
//             <img src={film.img} alt='film'/>
//         </li>
//         // eslint-disable-next-line react/prop-types
//
//     );
// }

// eslint-disable-next-line react/prop-types
export default function FilmMenu({hits, upcoming}){
    return <div className="FilmMenu">
        <h1 className="TextHit">NAJWIĘKSZE HITY!</h1>
        <ul className="films">
            {/* eslint-disable-next-line react/prop-types */}
            {hits.map((film, idx) => (
                <img src={film.src} alt={film.name} key={idx}/>
            ))}
        </ul>
        <h1 className="TextHit">WKRÓTCE!</h1>
        <ul className="films">
            {/* eslint-disable-next-line react/prop-types */}
            {upcoming.map((film, idx) => (
                <img src={film.src} alt={film.name} key={idx}/>
            ))}
        </ul>
    </div>

}
