import './App.css';
import TodoHeader from './Components/TodoHeader'
import TodoList from './Components/TodoList';
import TodoFooter from './Components/TodoFooter'
import { useState, useEffect } from 'react'

function App() {
  const [todos, setTodos] = useState([
    { id: 1, text: 'todo 1', isCompleted: false },
    { id: 2, text: 'todo 2', isCompleted: true },
    { id: 3, text: 'todo 3', isCompleted: false },
  ])

  const [todoDataSource, setTodoDataSource] = useState(todos)

  const [filter, setFilter] = useState('no-filter')

  const addTodo = todoText => {
    var todo = { id: Date.now(), text: todoText, isCompleted: false }
    setTodos([...todos, todo])
  }

  const toggleTodo = todoId => {
    setTodos(
      todos.map(
        todo => todo.id === todoId ?
          { ...todo, isCompleted: !todo.isCompleted } : todo
      )
    )
  }

  const deleteTodo = todoId => {
    setTodos(
      todos.filter(
        todo => todo.id !== todoId
      )
    )
  }

  const clearCompletedTodos = () => {
    setTodos(
      todos.filter(
        todo => todo.isCompleted === false
      )
    )
  }

  const removeFilter = () => {
    setTodoDataSource(todos)
    setFilter('no-filter')
  }

  const filterActive = () => {
    setTodoDataSource(
      todos.filter(todo => todo.isCompleted === false)
    )
    setFilter('active')
  }

  const filterCompleted = () => {
    setTodoDataSource(
      todos.filter(todo => todo.isCompleted === true)
    )
    setFilter('completed')
  }

  useEffect(() => {
    if (filter === 'active')
      filterActive()
    else if (filter === 'completed')
      filterCompleted()
    else
      removeFilter()
  }, [todos])

  return (
    <>
      <section className="todoapp">
        <TodoHeader addTodo={addTodo} />
        <TodoList
          todos={todoDataSource}
          toggleTodo={toggleTodo}
          deleteTodo={deleteTodo} />
        <TodoFooter
          todosCount={todoDataSource.length}
          clearCompletedTodos={clearCompletedTodos}
          filter={filter}
          removeFilter={removeFilter}
          filterActive={filterActive}
          filterCompleted={filterCompleted}
        />
      </section>

      <footer className="info">
        <p>Click to edit a todo</p>
        <p>Created by <a href="https://d12n.me/">Dmitry Sharabin</a></p>
        <p>Part of <a href="http://todomvc.com">TodoMVC</a></p>
      </footer>
    </>
  );
}

export default App;
