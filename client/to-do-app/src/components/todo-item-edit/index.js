"use client"
import React, { useState } from 'react'
import Modal from '@/components/modal'
import ModalOverlay from '@/components/modal-overlay'
import ModalCloseButton from '@/components/modal-close-button'
import ModalBody from '@/components/modal-body'
import ModalContent from '@/components/modal-content'
import ModalFooter from '@/components/modal-footer'
import ModalHeader from '@/components/modal-header'
import Button from '@/components/button'
import Input from '@/components/input'

const TodoItemEdit = async ({todo, isOpen, setIsOpen}) => {

    const [content, setContent] = useState(todo.content);

    const onClose = () => {
        setIsOpen(false);
    }

    return (
        <div>
            <Modal isOpen={isOpen} onClose={onClose}>
                <ModalOverlay />
                <ModalContent>
                    <ModalHeader>Edit Todo</ModalHeader>
                    <ModalCloseButton />
                    <ModalBody>
                        <Input value={content} onChange={(e) => setContent(e.target.value)} />
                    </ModalBody>
                    <ModalFooter>
                        <Button colorScheme='blue' mr={3} >
                            Save
                        </Button>
                        <Button variant='ghost' onClick={onClose}>Cancel</Button>
                    </ModalFooter>
                </ModalContent>
            </Modal>
        </div>
    )
}

export default TodoItemEdit