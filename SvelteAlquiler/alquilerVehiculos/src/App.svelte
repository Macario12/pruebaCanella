<script>
  import { v4 } from "uuid";
  import Noty from "noty";
  import "noty/lib/noty.css";
  let products = [
    {
      id: 1,
      name: "Hp Pavilion Notebook",
      description: "HP Laptop",
      category: "laptops"
    },
    {
      id: 2,
      name: "Razer Mouse",
      description: "Gaming Mouse",
      category: "peripherals"
    },
    {
      id: 3,
      name: "Corsair Keyboard",
      description: "Gaming keyboard",
      category: "peripherals"
    }
  ];
  async function fetchVehiculos(){
	const vehiculos = await fetch('http://localhost:5000/vehiculo');
	return vehiculos
  }
  let cliente = {
    codigo: "",
    nombres: "",
    apellidos: "",
  };
  let editStatus = false;
  const cleanProduct = () => {
    product = {
      id: "",
      name: "",
      description: "",
      category: "",
      imageURL: ""
    };
  };
  const addProduct = () => {
    const newProduct = {
      id: v4(),
      name: product.name,
      description: product.description,
      category: product.category,
      imageURL: product.imageURL
    };
    products = products.concat(newProduct);
    cleanProduct();
    console.log(products);
  };
  const deleteProduct = id => {
    console.log(id);
    products = products.filter(product => product.id !== id);
  };
  const editProduct = productEdited => {
    editStatus = true;
    product = productEdited;
    console.log(product);
  };
  const updateProduct = () => {
    let updatedProduct = {
      name: product.name,
      description: product.description,
      id: product.id,
      imageURL: product.imageURL,
      category: product.category
    };
    const productIndex = products.findIndex(p => p.id === product.id);
    products[productIndex] = updatedProduct;
    cleanProduct();
    new Noty({
      theme: "sunset",
      type: "success",
      timeout: 3000,
      text: "Product Update Successfully"
    }).show();
    editStatus = false;
  };
  const onSubmitHandler = () => {
    if (!editStatus) {
      addProduct();
    } else {
      updateProduct();
    }
  };
</script>

<style>
</style>

<main>
  <div class="container p-4">
    <div class="row">
      <div class="col-md-6">
        {#each products as product}
          <div class="card mt-2 animate__animated animate__backInLeft">
					<div class="row">
						<div class="col-md-4">
						{#if !product.imageURL}
						<img src="data:image/jpeg;base64,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" class="p-2 img-fluid" alt="Image"/>
						{:else}
						<img src="{product.imageURL}" class="p-2 img-fluid" alt="Image"/>
						{/if}
						</div>
						<div class="col-md-8">
            <div class="card-body">
              <h5 class="card-title">
                <strong>{product.name}</strong>
                <span>
                  <small>{product.category}</small>
                </span>
              </h5>
              <p class="card-text">{product.description}</p>
              <button
                class="btn btn-danger"
                on:click={deleteProduct(product.id)}>
                Delete
              </button>
              <button class="btn btn-secondary" on:click={editProduct(product)}>
                Edit
              </button>
            </div>
						</div>
					</div>
          </div>
        {/each}
      </div>
      <div class="col-md-6">
        <div class="card">
          <div class="card-body">
            <h2 class="card-title">
              {#if !editStatus}Agregar Vehiculo{:else}Actualizar Vehiculo{/if}
            </h2>
            <form on:submit|preventDefault={onSubmitHandler}>

				<div class="form-group">
					<label for="product-description">Matricula</label>
					<input
					bind:value={cliente.nombres}
					type="text"
					class="form-control"
					id="product-name"
					placeholder="Matricula" />
				  </div>

              <div class="form-group">
                <label for="product-name">Marca</label>
                <input
                  bind:value={cliente.nombres}
                  type="text"
                  class="form-control"
                  id="product-name"
                  placeholder="Marca" />
              </div>

              <div class="form-group">
                <label for="product-description">Color</label>
				<input
				bind:value={cliente.nombres}
				type="text"
				class="form-control"
				id="product-name"
				placeholder="Color" />
              </div>

			  <div class="form-group">
                <label for="product-description">precio Alquiler</label>
				<input
				bind:value={cliente.nombres}
				type="text"
				class="form-control"
				id="product-name"
				placeholder="precio Alquiler" />
              </div>
			
			  <div class="form-group">
                <label for="product-description">Dias Reserva</label>
				<input
				bind:value={cliente.nombres}
				type="text"
				class="form-control"
				id="product-name"
				placeholder="Dias Reserva" />
              </div>

			  <div class="form-group">
                <label for="product-description">Garaje</label>
				<input
				bind:value={cliente.nombres}
				type="text"
				class="form-control"
				id="product-name"
				placeholder="Graraje" />
              </div>

			  <div class="form-group">
                <label for="product-description">Precio Final</label>
				<input
				bind:value={cliente.nombres}
				type="text"
				class="form-control"
				id="product-name"
				placeholder="Precio Final" />
              </div>

			  <div class="form-group">
                <label for="product-description">Cliente</label>
				<input
				bind:value={cliente.nombres}
				type="text"
				class="form-control"
				id="product-name"
				placeholder="Cliente" />
              </div>

             <!--  <div class="form-group">
                <label for="produtc-image-url">Product Image URL</label>
                <input
                  bind:value={product.imageURL}
                  type="url"
                  id="product-image-url"
                  class="form-control"
                  placeholder="https://faztweb.com" />
              </div> -->

              <!-- <div class="form-group">
                <label for="category">Product Category</label>
                <select
                  id="category"
                  class="form-control"
                  bind:value={product.category}>
                  <option selected disabled>Select a Category</option>
                  <option value="laptops">Laptops</option>
                  <option value="peripherals">Peripherals</option>
                  <option value="servers">Servers</option>
                </select>
              </div> -->
              <button type="submit" class="btn btn-primary">
                {#if !editStatus}Save Product{:else}Update Product{/if}
              </button>
            </form>

          </div>
        </div>
      </div>
    </div>
  </div>
</main>