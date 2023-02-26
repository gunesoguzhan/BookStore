import TodoItem from './TodoItem';

function TodoList({ todos, toggleTodo, deleteTodo }) {
    return (
        <section className="main">
            <input className="toggle-all" type="checkbox" />
            <label htmlFor="toggle-all">
                Mark all as complete
            </label>
            <ul className="todo-list">
                {
                    todos.map(todo => {
                        return (
                            <TodoItem
                                key={todo.id}
                                todo={todo}
                                toggleTodo={toggleTodo}
                                deleteTodo={deleteTodo} />
                        )
                    })
                }
            </ul>
        </section >
    )
}

export default TodoList