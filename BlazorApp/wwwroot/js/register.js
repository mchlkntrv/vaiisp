async function registerUser(data) {
    const response = await fetch('http://localhost:5023/api/auth/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });

    console.log(response);
    if (response.ok) {
        return true;
    } else {
        throw new Error('Registration failed');
    }
}
