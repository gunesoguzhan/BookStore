function TodoItem({ todo, toggleTodo, deleteTodo }) {
    const checkTodo = () => {
        toggleTodo(todo.id)
    }

    const destroyTodo = () => {
        deleteTodo(todo.id)
    }

    return (
        <li className={todo.isCompleted && "completed"}>
            <div className="view">
                <input
                    className="toggle"
                    type="checkbox"
                    onClick={checkTodo}
                    checked={todo.isCompleted} />
                <label>{todo.text}</label>
                <button className="destroy" onClick={destroyTodo}></button>
            </div>
        </li >
    )
}

export default TodoItem