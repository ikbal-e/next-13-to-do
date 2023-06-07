"use client"
import React, { useState } from 'react'
import SimpleGrid from '@/components/simple-grid';
import Card from '@/components/card';
import CardHeader from '@/components/card-header';
import CardBody from '@/components/card-body';
import CardFooter from '@/components/card-footer';
import Button from '@/components/button';
import Heading from '@/components/heading';
import Text from '@/components/text';
import TodoItem from '@/components/todo-item';

const TodoListContainer = ({ todos }) => {

    return (
        <div>
            <SimpleGrid mt={5} spacing={4} templateColumns='repeat(auto-fill, minmax(200px, 1fr))'>
                <Card>
                    <CardHeader>
                        <Heading size='md'>Example</Heading>
                    </CardHeader>
                    <CardBody>
                        <Text>Example</Text>
                    </CardBody>
                    <CardFooter>
                        <Button>View here</Button>
                    </CardFooter>
                </Card>
                {todos.map((todo) => (
                    <TodoItem key={todo.id} todo={todo} />
                ))}
            </SimpleGrid>
        </div>
    )
}

export default TodoListContainer