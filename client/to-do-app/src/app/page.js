
import Image from 'next/image'
import styles from './page.module.css'
import TodoListContainer from '@/containers/todo-list'
import { fetchTodos } from '@/services/todos'
import AddTodoContainer from '@/containers/add-todo'

export default async function Home() {

  const todos = await fetchTodos();
  console.log(todos);

  return (
    <main>
      <div>
        <AddTodoContainer />
        <TodoListContainer todos={todos} />

      </div>
    </main>
  )
}
