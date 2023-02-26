import { useState } from "react"

function TodoForm({ addTodo }) {
    const [form, setForm] = useState({ todoInput: '' })

    const inputOnChange = e => {
        setForm({ ...form, [e.target.name]: e.target.value })
    }

    const formOnSubmit = e => {
        e.preventDefault()
        if (form.todoInput === '')
            return;
        addTodo(form.todoInput)
        setForm({ todoInput: '' })
    }

    return (
        <form onSubmit={formOnSubmit}>
            <input
                className="new-todo"
                placeholder="What needs to be done?"
                autoFocus
                name="todoInput"
                value={form.todoInput}
                onChange={inputOnChange} />
        </form>
    )
}

export default TodoForm