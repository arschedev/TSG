import { useState } from "react"
import "./Input.css"

export function Input(props) {
	const [interacted, setInteracted] = useState(false)

	return (
		<label>
			{props.label}
			<br />
			<input
				type="text"
				className={interacted ? "interacted" : ""}
				onBlur={() => setInteracted(true)}
				placeholder="*"
				required
				{...props}></input>
			<br />
		</label>
	)
}
