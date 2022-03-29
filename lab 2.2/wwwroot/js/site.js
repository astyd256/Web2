if ("userForm1" in document.forms) {

	var userFormManual = document.forms["userForm1"];
	var numbers = userFormManual.getElementsByClassName("number");
	var operator = userFormManual.elements["operator"]

	userFormManual.addEventListener("submit", e => {
		e.preventDefault();
		Request1();
	})

	async function Request1() {
		const response = await fetch("/api/calc/" + numbers[0].value + "/" + operator.value + "/" + numbers[1].value, {
			method: "GET",
			headers: { "Accept": "application/json" }
		});
		if (response.ok === true)
			userFormManual.getElementsByClassName("answer")[0].textContent = numbers[0].value + " " + operator.value + " " + numbers[1].value + " = " + await response.text();
		else
			userFormManual.getElementsByClassName("answer")[0].textContent = "Error getting response!";

		userFormManual.getElementsByClassName("result")[0].style.display = "Block";
		userFormManual.getElementsByClassName("main")[0].style.display = "None";
	}
}
else if ("userForm2" in document.forms) {
	var userFormManual = document.forms["userForm2"];
	var numbers = userFormManual.getElementsByClassName("number");
	var operator = userFormManual.elements["operator"]
	userFormManual.addEventListener("submit", e => {
		e.preventDefault();
		switch (operator.value) {
			case "+":
				RequestSummarize();
			case "-":
				RequestSubtract();
			case "*":
				RequestMultiply();
			case "/":
				RequestDivide();
		}
	})

	async function RequestSummarize() {
		const response = await fetch("/api/calc/summarize/" + numbers[0].value + "/" + numbers[1].value, {
			method: "GET",
			headers: { "Accept": "application/json" }
		});
		if (response.ok === true)
			userFormManual.getElementsByClassName("answer")[0].textContent = numbers[0].value + " + " + numbers[1].value + " = " + await response.text();
		else
			userFormManual.getElementsByClassName("answer")[0].textContent = "Error getting response!";
		userFormManual.getElementsByClassName("result")[0].style.display = "Block";
		userFormManual.getElementsByClassName("main")[0].style.display = "None";
	}

	async function RequestSubtract() {
		const response = await fetch("/api/calc/subtract/" + numbers[0].value + "/" + numbers[1].value, {
			method: "GET",
			headers: { "Accept": "application/json" }
		});
		if (response.ok === true)
			userFormManual.getElementsByClassName("answer")[0].textContent = numbers[0].value + " - " + numbers[1].value + " = " + await response.text();
		else
			userFormManual.getElementsByClassName("answer")[0].textContent = "Error getting response!";
		userFormManual.getElementsByClassName("result")[0].style.display = "Block";
		userFormManual.getElementsByClassName("main")[0].style.display = "None";
	}

	async function RequestMultiply() {
		const response = await fetch("/api/calc/multiply/" + numbers[0].value + "/" + numbers[1].value, {
			method: "GET",
			headers: { "Accept": "application/json" }
		});
		if (response.ok === true)
			userFormManual.getElementsByClassName("answer")[0].textContent = numbers[0].value + " * " + numbers[1].value + " = " + await response.text();
		else
			userFormManual.getElementsByClassName("answer")[0].textContent = "Error getting response!";
		userFormManual.getElementsByClassName("result")[0].style.display = "Block";
		userFormManual.getElementsByClassName("main")[0].style.display = "None";
	}

	async function RequestDivide() {
		const response = await fetch("/api/calc/divide/" + numbers[0].value + "/" + numbers[1].value, {
			method: "GET",
			headers: { "Accept": "application/json" }
		});
		if (response.ok === true)
			userFormManual.getElementsByClassName("divide")[0].textContent = numbers[0].value + " / " + numbers[1].value + " = " + await response.text();
		else
			userFormManual.getElementsByClassName("answer")[0].textContent = "Error getting response!";
		userFormManual.getElementsByClassName("result")[0].style.display = "Block";
		userFormManual.getElementsByClassName("main")[0].style.display = "None";
	}
}






