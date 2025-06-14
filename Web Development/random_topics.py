import random as rd

topics = [
    "Topic: Student Attendance Management System",
    "Topic: Tourism Management",
    "Topic: Hospital Patient Management System",
    "Topic: Video LiveStream System",
]
for _ in range(1000):
    rd.shuffle(topics)
chosen_topic = rd.choice(topics)
print(f"chosen_topic: {chosen_topic}")
