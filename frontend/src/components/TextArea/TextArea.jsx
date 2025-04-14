import { useState } from "react"
import "./TextArea.css"

export function TextArea(props) {
	const [interacted, setInteracted] = useState(false)

	return (
		<label>
			{props.label}
			<textarea
				className={interacted ? "interacted" : ""}
				onBlur={() => setInteracted(true)}
				placeholder="Minim 100 caractere"
				required
				{...props}></textarea>
			<br />
		</label>
	)
}
