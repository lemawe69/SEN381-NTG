document.addEventListener("DOMContentLoaded", () => {
    const sendBtn = document.getElementById("sendBtn");
    const input = document.getElementById("userInput");
    const chatWindow = document.getElementById("chatWindow");

    function appendMessage(content, sender) {
        const msg = document.createElement("div");
        msg.classList.add("message", sender === "user" ? "user-message" : "bot-message");
        msg.textContent = content;
        chatWindow.appendChild(msg);
        chatWindow.scrollTop = chatWindow.scrollHeight;
    }

    function handleSend() {
        const text = input.value.trim();
        if (text === "") return;

        appendMessage(text, "user");
        input.value = "";

        setTimeout(() => {
            appendMessage("🤖 LM Studio: That’s an interesting point! Let me think about it...", "bot");
        }, 600);
    }

    sendBtn.addEventListener("click", handleSend);
    input.addEventListener("keypress", (e) => {
        if (e.key === "Enter") handleSend();
    });
});
