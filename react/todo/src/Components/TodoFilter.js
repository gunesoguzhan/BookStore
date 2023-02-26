function TodoFilter({ filter, removeFilter, filterActive, filterCompleted }) {
    return (
        <ul className="filters">
            <li>
                <a
                    href="#/"
                    className={filter === "no-filter" ? "selected" : ""}
                    onClick={removeFilter}
                >
                    All
                </a>
            </li>
            <li>
                <a
                    href="#/"
                    className={filter === "active" ? "selected" : ""}
                    onClick={filterActive}
                >
                    Active
                </a>
            </li>
            <li>
                <a
                    href="#/"
                    className={filter === "completed" ? "selected" : ""}
                    onClick={filterCompleted}
                >
                    Completed
                </a>
            </li>
        </ul>
    )
}

export default TodoFilter