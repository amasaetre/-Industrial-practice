import sqlite3

class Database:
    def __init__(self):
        # Инициализация Базы Данных
        self.__db_connection = sqlite3.connect('app.db', check_same_thread=False)

        # Инициализация курсора для исполнения запросов
        cursor = self.__db_connection.cursor()

        # Создаем таблицу с пользователями если не существует
        cursor.execute('''
        CREATE TABLE IF NOT EXISTS Users (
        id INTEGER PRIMARY KEY,
        login TEXT NOT NULL,
        password TEXT NOT NULL
        )
        ''')

        # Создаем таблицу с задачами если не существует
        cursor.execute('''
        CREATE TABLE IF NOT EXISTS Tasks (
        id INTEGER PRIMARY KEY,
        name TEXT NOT NULL,
        date TEXT NOT NULL,
        priority INTEGER NOT NULL,
        user_id INTEGER NOT NULL
        )
        ''')

        # Подтверждаем изменения
        self.__db_connection.commit()

    def __del__(self):
        # Удаление объекта = закрытое соединение
        self.__db_connection.close()

    # Метод добавления пользователя в Базу Данных
    def add_user(self, login, password):
        cursor = self.__db_connection.cursor()
        cursor.execute('INSERT INTO Users (login, password) VALUES (?, ?)', (login, password))
        self.__db_connection.commit()

    # Метод получения пароля пользователя по логину
    def get_user(self, login):
        cursor = self.__db_connection.cursor()
        cursor.execute('SELECT * FROM Users WHERE login=?', (login,))
        return cursor.fetchall()

    # Метод добавления задачи
    def add_task(self, name, date, priority, user_id):
        cursor = self.__db_connection.cursor()
        cursor.execute('INSERT INTO Tasks (name, date, priority, user_id) VALUES (?, ?, ?, ?)', (name, date, priority, user_id))
        self.__db_connection.commit()

    # Метод удаления задачи
    def delete_task(self, id):
        cursor = self.__db_connection.cursor()
        cursor.execute('DELETE FROM Tasks WHERE id=?', (id,))
        self.__db_connection.commit()

    # Метод получения задачи
    def get_task(self, id):
        cursor = self.__db_connection.cursor()
        cursor.execute('SELECT * FROM Tasks WHERE id=?', (id,))
        self.__db_connection.commit()

    #TODO Метод обновления данных задачи
    # def update_task(self, name, date, priority, user_id):
    #     cursor = self.__db_connection.cursor()
    #     cursor.execute('UPDATE Tasks SET ()')
