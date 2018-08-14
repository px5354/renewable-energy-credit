import axios from 'axios';

function build(form) {
  return {
    PermanentCode: form.permanentCode,
    University: form.university,
    GraduationYear: form.graduationYear,
    Program: form.program,
    Gpa: form.gpa,
  };
}

export const getUniversities = () => axios({
  method: 'get',
  baseURL: 'https://graduationchecker.azurewebsites.net',
  url: 'api/data/university',
});

export const getPrograms = (universityId, degree, year) => axios({
  method: 'get',
  baseURL: 'https://graduationchecker.azurewebsites.net',
  url: 'api/data/program',
  params: {
    universityId,
    degree,
    year,
  },
});

export const verifyCertificate = form => axios({
  method: 'post',
  baseURL: 'https://graduationchecker.azurewebsites.net',
  url: 'api/keeper',
  data: build(form),
  config: { headers: { 'Content-Type': 'application/json' } },
});

export const getAssets = () => axios({
  method: 'get',
  baseURL: 'http://localhost:43056',
  url: 'api/tracker/assets',
});

export const getTransactions = () => axios({
  method: 'get',
  baseURL: 'http://localhost:43056',
  url: 'api/tracker/transactions',
});

