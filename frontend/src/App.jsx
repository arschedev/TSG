import { useState } from "react"
import { Input } from "./components/Input/Input"
import { TextArea } from "./components/TextArea/TextArea"
import { Button } from "./components/Button/Button"
import "./App.css"

function App() {
	const [formData, setFormData] = useState({
		Nume: "",
		Prenume: "",
		Facultate: "",
		Motivatie: ""
	})

	const download = (href, name) => {
		const a = document.createElement("a")
		a.href = href
		a.download = name
		a.click()
	}

	const handleChange = (event) => {
		const { name, value } = event.target
		setFormData((data) => ({
			...data,
			[name]: value
		}))
	}

	const handleSubmit = async (event) => {
		event.preventDefault()
		console.log(formData)

		const response = await fetch("/api/forms", {
			method: "POST",
			headers: {
				"Content-Type": "application/json"
			},
			body: JSON.stringify(formData)
		})

		console.log(response)

		if (!response.ok) {
			return alert(response.statusText)
		}

		const blob = await response.blob()
		const href = URL.createObjectURL(blob)
		download(href, "StudentForm.pdf")
	}

	return (
		<form onSubmit={handleSubmit}>
			<Input
				label="Nume"
				name="Nume"
				value={formData.Nume}
				onChange={handleChange}></Input>
			<Input
				label="Prenume"
				name="Prenume"
				value={formData.Prenume}
				onChange={handleChange}></Input>
			<Input
				label="Facultate"
				name="Facultate"
				value={formData.Facultate}
				onChange={handleChange}></Input>
			<TextArea
				label="Motivație participare"
				name="Motivatie"
				value={formData.Motivatie}
				onChange={handleChange}
				minLength={100}></TextArea>

			<br />
			<Button type="submit">Submit</Button>
		</form>
	)
}

export default App
