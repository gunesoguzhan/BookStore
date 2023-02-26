import TodoFilter from "./TodoFilter"

function TodoFooter(
    {
        todosCount,
        clearCompletedTodos,
        filter,
        removeFilter,
        filterActive,
        filterCompleted
    }) {
    return (
        <footer className="footer">
            <span className="todo-count">
                <strong>{todosCount} </strong>
                items
            </span>

            <TodoFilter
                filter={filter}
                removeFilter={removeFilter}
                filterActive={filterActive}
                filterCompleted={filterCompleted}
            />

            <button className="clear-completed" onClick={clearCompletedTodos}>
                Clear completed
            </button>
        </footer>
    )
}

export default TodoFooter