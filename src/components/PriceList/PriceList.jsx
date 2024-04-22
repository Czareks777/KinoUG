import "./PriceList.css";

// eslint-disable-next-line react/prop-types
function PriceList() {
  return (
    <div className="price-list-container">
      <div className="prices-container">
        <p>Cennik</p>
        <div className="ticket-container">
          <div className="ticket">
            <h1>Normalny</h1>
            <h1>20zł</h1>
          </div>
          <div className="ticket">
            <h1>Junior</h1>
            <h1>15zł</h1>
          </div>
          <div className="ticket">
            <h1>Senior</h1>
            <h1>10zł</h1>
          </div>
        </div>
      </div>
      <div className="info-container">
        <h1>Informacje o biletach</h1>
        <div className="ticket-info">
          <h2>Bilet junior</h2>
          <p>
            Przysługuje osobom poniżej 18 roku życia i dla studentów za
            pokazaniem legitymacji studenckiej.
          </p>
        </div>
        <div className="ticket-info">
          <h2>Bilet senior</h2>
          <p>Przysługuje osobom powyżej 65 roku życia, emerytom i rencistom.</p>
        </div>
      </div>
    </div>
  );
}

export default PriceList;

// {data.map((ticket, idx) => (
//     <img key={idx} src={ticket.src} alt={ticket.alt} />
// ))}
