import os
import time
import git


DIRECTORY_TO_BACKUP = '#'
REPO_PATH = '#'


def check_changes(repo):

    changed_files = repo.git.diff(name_only=True)
    return bool(changed_files)


def commit_changes(repo):

    repo.git.add(A=True)
    repo.index.commit("Автоматическое резервное копирование: " + time.strftime("%Y-%m-%d %H:%M:%S"))


def push_changes(repo):

    repo.git.push('origin', 'main')


def main():
    repo = git.Repo(REPO_PATH)
    while True:
        if check_changes(repo):
            print("Изменения обнаружены. Создаю коммит...")
            commit_changes(repo)
            push_changes(repo)
            print("Изменения отправлены на удаленный репозиторий.")
        else:
            print("Изменений не обнаружено.")


        time.sleep(3600)


if __name__ == '__main__':
    main()
