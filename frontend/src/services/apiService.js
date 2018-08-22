import axios from 'axios';

function buildCreateAssetForm(form) {
  return {
    Type: form.energyType,
  };
}

function buildIssueAmountForm(form) {
  return {
    AssetId: form.energyId,
    RecipientEmail: form.email,
    Amount: form.quantity,
  };
}

function buildTransferAssetForm(form) {
  return {
    RecipientEmail: form.recipientEmail,
    Amount: form.amount,
    FactoryId: form.factoryId,
    SenderEmail: form.senderEmail,
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

export const createAsset = (form) => axios({
  method: 'post',
  baseURL: 'http://localhost:43056',
  url: 'api/tracker',
  data: buildCreateAssetForm(form),
  config: { headers: { 'Content-Type': 'application/json' } },
});

export const getAssets = () => axios({
  method: 'get',
  baseURL: 'http://localhost:43056',
  url: 'api/tracker/assets',
});

export const getAssetDetails = (assetId) => axios({
  method: 'get',
  baseURL: 'http://localhost:43056',
  url: `api/tracker/assets/issuedbatches/${assetId}`,
});

export const issueAmount = (form) => axios({
  method: 'post',
  baseURL: 'http://localhost:43056',
  url: 'api/tracker/assets/issue',
  data: buildIssueAmountForm(form),
  config: { headers: { 'Content-Type': 'application/json' } },
});

export const transferAmount = (form) => axios({
  method: 'post',
  baseURL: 'http://localhost:43056',
  url: 'api/tracker/wallet/transfer',
  data: buildTransferAssetForm(form),
  config: { headers: { 'Content-Type': 'application/json' } },
});

export const getTransactions = () => axios({
  method: 'get',
  baseURL: 'http://localhost:43056',
  url: 'api/tracker/transactions',
});

export const getBalances = () => axios({
  method: 'get',
  baseURL: 'http://localhost:43056',
  url: 'api/tracker/balances',
});

