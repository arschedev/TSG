FROM node:20

# Set working directory
WORKDIR /app

# Copy frontend files
COPY ./ ./

# Install dependencies
RUN npm install

# Expose the Vite dev server port
EXPOSE 5173

# Start Vite dev server
CMD ["npm", "run", "dev", "--", "--host"]
