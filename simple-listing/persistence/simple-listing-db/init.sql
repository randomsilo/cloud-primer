DROP SCHEMA simple_listing CASCADE;

CREATE SCHEMA simple_listing;

CREATE TABLE simple_listing.sentences (
  id BIGINT GENERATED ALWAYS AS IDENTITY,
  sentence TEXT,
  createdOn TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  updatedOn TIMESTAMPTZ DEFAULT NULL
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