import { useContext, useState } from "react";
import "./Profile.css";
import AppContext from "../../../../features/_context/AppContext";
import { clearRememberUser } from "../../../../entities/user/lib/UserLib";

export default function Profile() {
    const { user, setUser } = useContext(AppContext);
    const [confirmDelete, setConfirmDelete] = useState(false);

    const logout = () => {
        clearRememberUser();
        setUser(undefined);
    };

    
    const deleteProfile = () => {
        if (!confirmDelete) return;

        clearRememberUser();
        setUser(undefined);

        alert("Профіль видалено");
    };

    return (
        <div className="profile-container">
            <div className="card profile-card shadow-lg">

                <div className="profile-header">
                    <div className="avatar">
                        <i className="bi bi-person-fill"></i>
                    </div>
                    <h2>Профіль користувача</h2>
                </div>

                <div className="profile-info">
                    <div className="profile-item">
                        <span>Логін</span>
                        <strong>{user?.login}</strong>
                    </div>

                    <div className="profile-item">
                        <span>Ім'я</span>
                        <strong>{user?.name}</strong>
                    </div>

                    <div className="profile-item">
                        <span>E-mail</span>
                        <strong>{user?.email}</strong>
                    </div>
                </div>

                <button
                    className="btn btn-warning w-100 mb-3"
                    onClick={logout}
                >
                    <i className="bi bi-box-arrow-right me-2"></i>
                    Вийти
                </button>

                <div className="form-check mb-3">
                    <input
                        className="form-check-input"
                        type="checkbox"
                        id="deleteProfile"
                        checked={confirmDelete}
                        onChange={(e) =>
                            setConfirmDelete(e.target.checked)
                        }
                    />
                    <label
                        className="form-check-label"
                        htmlFor="deleteProfile"
                    >
                        Я підтверджую видалення профілю
                    </label>
                </div>

                <button
                    className="btn btn-danger w-100"
                    disabled={!confirmDelete}
                    onClick={deleteProfile}
                >
                    <i className="bi bi-trash me-2"></i>
                    Видалити профіль
                </button>

            </div>
        </div>
    );
}