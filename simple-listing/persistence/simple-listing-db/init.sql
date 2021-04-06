DROP SCHEMA simple_listing CASCADE;

CREATE SCHEMA simple_listing;

CREATE TABLE simple_listing.sentences (
  id SERIAL PRIMARY KEY,
  sentence TEXT,
  created_on TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  updated_on TIMESTAMPTZ DEFAULT NULL
);

INSERT INTO 
  simple_listing.sentences (sentence) 
VALUES
	 ('First')
	,('Second')
	,('Third')
	,('Fourth')
	,('Fifth')
;