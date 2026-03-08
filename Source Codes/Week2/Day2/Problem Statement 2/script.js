const products = [
  { name: "Laptop", price: 43750, quantity: 1 },
  { name: "Mouse", price: 500, quantity: 1 },
  { name: "Keyboard", price: 1500, quantity: 1 },
  { name: "Laptop Bag", price: 1200, quantity: 1 }
];

const calculateTotal = (items) => 
  items
    .map(item => item.price * item.quantity)
    .reduce((total, value) => total + value, 0);

const generateInvoice = (items) => {
  const total = calculateTotal(items);

  const productDetails = items
    .map(item => 
      `${item.name} - ₹${item.price} x ${item.quantity} = ₹${item.price * item.quantity}`
    )
    .join("\n");

  return `
-------- INVOICE --------
${productDetails}
------------------------
Total Amount: ₹${total}
------------------------
`;
};

const invoice = generateInvoice(products);

document.getElementById("output").textContent = invoice;