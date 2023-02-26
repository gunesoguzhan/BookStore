import TodoForm from './TodoForm'

function TodoHeader({ addTodo }) {
    return (
        <header className="header">
            <h1>todos</h1>
            <TodoForm addTodo={addTodo} />
        </header>
    )
}

export default TodoHeader